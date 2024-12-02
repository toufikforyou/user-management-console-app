namespace InputErrorNamespace
{
    class InputError : Exception
    {
        public InputError(string err) : base(err) { }
    }
}