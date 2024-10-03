using Bogus;

namespace TeamcityTestingFramework.Api.Generators
{
    public sealed class RandomData
    {
        private static readonly string TEST_PREFIX = "test_";
        private static readonly int MAX_LENGTH = 10;

        public static string GetString()
        {
            var faker = new Faker();
            return $"{TEST_PREFIX}{faker.Random.String2(MAX_LENGTH)}";
        }

        public static string GetString(int length)
        {
            var faker = new Faker();
            return $"{TEST_PREFIX}{faker.Random.String2(Math.Max(length - TEST_PREFIX.Length, MAX_LENGTH))}";
        }
    }
}
