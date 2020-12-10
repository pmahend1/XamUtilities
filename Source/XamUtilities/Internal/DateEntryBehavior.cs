using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using XamUtilities.Views;

namespace XamUtilities.Internal
{
    public class DateEntryBehavior : Behavior<Entry>
    {
        private IDictionary<int, char> _positions;
        private Dictionary<int, string> Parts = new Dictionary<int, string>();
        private string Separator;

        private string _mask = "";

        public string Mask
        {
            get => _mask;
            set
            {
                _mask = value;
                SetPositions();
            }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            SetPositions();
            var dateEntry = (DateEntry)bindable;

            var rx = new Regex(@"\w+|'[\w\s]*'");
            var matches = rx.Matches(dateEntry.Format);

            var rgx = new Regex(@"[^a-zA-Z0-9\s]+");
            var spCharMatches = rgx.Matches(dateEntry.Format);
            Separator = spCharMatches[0].Value ?? "/";

            string maskTemp = string.Empty;
            for (int i = 0; i < matches.Count; i++)
            {

                Parts.Add(i, matches[i].Value);
                if (i != 0)
                    maskTemp += Separator;
                if (Parts[i].Contains("M"))
                {
                    maskTemp += "MM";
                }
                if (Parts[i].Contains("d"))
                {
                    maskTemp += "dd";
                }

                if (Parts[i].Contains("y"))
                {
                    maskTemp += "yyyy";
                }
               
            }



            Mask = maskTemp;
            dateEntry.TextChanged += OnDateEntryTextChanged;

        }

        private void OnDateEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as DateEntry;

            var text = entry.Text;

            if (string.IsNullOrWhiteSpace(text) || _positions == null)
                return;

            if (text.Length > _mask.Length)
            {
                entry.Text = text.Remove(text.Length - 1);
                return;
            }
            //string text = string.Empty;
            if (Parts.Count == 3)
            {
                var rx = new Regex(@"\w+|'[\w\s]*'");
                var matches = rx.Matches(entry.Text);
                string updatedText = string.Empty;
                for (int i = 0; i < matches.Count; i++)
                {
                    Debug.WriteLine("Match value: " + matches[i].Value);
                    if (int.TryParse(matches[i].Value, out var part))
                    {
                        Debug.WriteLine(part);
                        if (i != 0)
                            updatedText += Separator;
                        if (Parts[i].Contains("M"))
                        {
                            updatedText += (part > 12) ? "12" : part.ToString();
                        }
                        if (Parts[i].Contains("d"))
                        {
                            updatedText += (part > 31) ? "31" : part.ToString();
                        }

                        if (Parts[i].Contains("y"))
                        {
                            updatedText += (part > 9999) ? "9999" : part.ToString();
                        }
                    }
                }
                if (entry.Text != updatedText)
                    entry.Text = updatedText;
            }
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnDateEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void SetPositions()
        {
            if (string.IsNullOrEmpty(Mask))
            {
                _positions = null;
                return;
            }

            var list = new Dictionary<int, char>();
            for (var i = 0; i < Mask.Length; i++)
                if (!char.IsLetter(Mask[i]))
                    list.Add(i, Mask[i]);

            _positions = list;
        }
    }
}