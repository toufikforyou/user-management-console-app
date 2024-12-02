namespace UserErrorNamespace
{
    class UserError : Exception
    {
        public UserError(string err) : base(err) { }
    }
}