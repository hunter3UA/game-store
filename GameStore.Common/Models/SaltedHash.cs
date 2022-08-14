namespace GameStore.Common.Models
{
    public class SaltedHash
    {
        public byte[] Hash { get; set; }

        public byte[] Salt { get; set; }
    }
}
