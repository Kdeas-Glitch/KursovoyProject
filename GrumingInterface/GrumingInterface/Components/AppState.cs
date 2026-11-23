namespace GrumingInterface.Components
{
    public class AppState
    {
        public long? VkUserId { get; private set; }
        public string UserFullName { get; private set; } = "Гость";
        public bool IsAuthenticated => VkUserId.HasValue;

        public HttpClient client = new();

        public AppState()
        {
            client.BaseAddress = new Uri("https://localhost:7073/");
        }

        public event Action? OnChange;

        public void SetVkUser(long vkUserId, string firstName, string lastName)
        {
            VkUserId = vkUserId;
            UserFullName = $"{firstName} {lastName}".Trim();
            NotifyStateChanged();
        }

        public void ClearUser()
        {
            VkUserId = null;
            UserFullName = "Гость";
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
