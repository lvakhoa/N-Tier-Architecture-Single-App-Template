namespace NTierArchitecture.Shared.Claim
{
    public interface IClaimService
    {
        string GetUserId();

        string GetClaim(string key);
    }
}
