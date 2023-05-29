namespace Join
{
    public class Record : IComparable<Record>
    {
        public string KeyField { get; }
        private List<string> Fields { get; }

        public Record(string row)
        {
            string[] tokens = row.Split('\t');
            KeyField = tokens[0];
            Fields = new List<string>(new ArraySegment<string>(tokens, 1, tokens.Length - 1));
        }

        public Record(string keyField, List<string> fields)
        {
            KeyField = keyField;
            Fields = fields;
        }

        public Record CreateUnion(Record other)
        {
            if (!string.Equals(KeyField, other.KeyField, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Key fields are not equal");
            }
            List<string> fields = new(Fields);
            fields.AddRange(other.Fields);
            return new Record(KeyField, fields);
        }

        public int CompareTo(Record? other)
        {
            if (other == null)
            {
                return 1;
            }
            return string.Compare(KeyField, other.KeyField, StringComparison.OrdinalIgnoreCase);
        }

        override public string ToString()
        {
            return KeyField + "\t" + string.Join("\t", Fields);
        }
    }
}
