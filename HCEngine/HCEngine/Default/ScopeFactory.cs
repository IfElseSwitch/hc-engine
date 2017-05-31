namespace HCEngine.Default
{
    class ScopeFactory : IScopeFactory
    {
        public IExecutionScope MakeScope()
        {
            IExecutionScope scope = new ExecutionScope();
            //TODO Fill scope with exposed calls and types
            return scope;
        }
    }
}
