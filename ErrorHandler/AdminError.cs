namespace AdminErrorNamespace
{
    class AdminError : Exception
    {
        public AdminError(string err) : base(err) { }
    }
}