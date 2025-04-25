namespace Backend.Contracts
{
    public record CategoryResponce(
        Guid categoryId,
        string Name,
        string Description);
}