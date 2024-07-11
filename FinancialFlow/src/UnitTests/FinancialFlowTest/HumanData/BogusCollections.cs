using Bogus;
using FinancialFlow.Core.DomainObjects.Enums;
using FinancialFlow.Domain.Entities;

namespace FinancialFlowTest.HumanData
{
    [CollectionDefinition("BogusCollections")]
    public class BogusCollections : ICollectionFixture<ProfileBogusFixture>
    {
    }







    public class ProfileBogusFixture
    {
        public FinancialTransaction GenerateFinancialTransaction_Valid() => Generate(1).FirstOrDefault();
        public FinancialTransaction GenerateFinancialTransaction_Invalid() => GenerateInvalid(1).FirstOrDefault();


        public IEnumerable<FinancialTransaction> Generate(int quantidade)
        {
            var profileFaker = new Faker<FinancialTransaction>("pt_BR")
                .CustomInstantiator(f => new FinancialTransaction(
                    f.Random.Guid(),
                    f.Date.Recent().ToUniversalTime(),
                    f.Finance.Amount(0, 1000, 2),
                    f.Lorem.Sentence(),
                    f.PickRandom<ETransactionType>()
                ));
            return profileFaker.Generate(quantidade);
        }

        public IEnumerable<FinancialTransaction> GenerateInvalid(int quantidade)
        {
            var profileFaker = new Faker<FinancialTransaction>("pt_BR")
                .CustomInstantiator(f => new FinancialTransaction(
                    f.Random.Guid(),
                    f.Date.Recent().ToUniversalTime(),
                    0,
                    f.Lorem.Sentence(),
                    f.PickRandom<ETransactionType>()
                ));
            return profileFaker.Generate(quantidade);
        }
    }
}
