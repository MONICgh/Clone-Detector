using System.Text;

namespace Join
{
    public class DataBase
    {
        private List<Record> Rows { get; }

        public DataBase(string[] _rows)
        {
            Rows = new List<Record>();
            foreach (string _row in _rows)
            {
                Rows.Add(new Record(_row));
            }
            Rows.Sort();
        }

        public DataBase(List<Record> _rows)
        {
            Rows = _rows;
        }

        public DataBase Join(DataBase other)
        {
            List<Record> joinRecords = new();
            int indLess = -1;
            int indLessOrEqual = -1;
            foreach (Record row in Rows)
            {
                while (indLess != other.Rows.Count - 1 && string.Compare(other.Rows[indLess + 1].KeyField, row.KeyField,
                    StringComparison.OrdinalIgnoreCase) < 0)
                {
                    indLess++;
                }
                while (indLessOrEqual != other.Rows.Count - 1 && string.Compare(other.Rows[indLessOrEqual + 1].KeyField,
                    row.KeyField, StringComparison.OrdinalIgnoreCase) <= 0)
                {
                    indLessOrEqual++;
                }
                for (int i = indLess + 1; i <= indLessOrEqual; i++)
                {
                    joinRecords.Add(row.CreateUnion(other.Rows[i]));
                }
            }
            return new DataBase(joinRecords);
        }

        override public string ToString()
        {
            StringBuilder result = new();
            foreach (Record row in Rows)
            {
                result.Append(row);
                result.Append('\n');
            }
            return result.ToString();
        }
    }
}