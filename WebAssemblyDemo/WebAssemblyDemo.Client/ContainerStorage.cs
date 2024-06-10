namespace WebAssemblyDemo.Client
{
    public class ContainerStorage
    {
        private string message = string.Empty;

        public string GetMessage() => message;

        public void SetMessage(string message) => this.message = message;
    }
}
