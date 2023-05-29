namespace HW02.HashTable
{
    internal struct HashTableItem<T>
    {
        public T Content { get; private set; }
        private bool _hadObject;
        public bool NotEmpty { get; private set; }

        public void SetContent(T value)
        {
            Content = value;
            _hadObject = true;
            NotEmpty = true;
        }

        public void ClearContent()
        {
            Content = default(T);
            NotEmpty = false;
        }

        public bool IsEmpty { get { return !NotEmpty && !_hadObject; } }
        public bool IsDeleted { get { return !NotEmpty && _hadObject; } }
    }
}
