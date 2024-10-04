using NHamcrest;

namespace TeamcityTestingFramework.Api.Matchers
{
    public class ContainsStringMatcher : IMatcher<string>
    {
        private readonly string _expectedString;

        public ContainsStringMatcher(string expectedString)
        {
            _expectedString = expectedString;
        }

        public bool Matches(string actual)
        {
            return actual.Contains(_expectedString);
        }

        public void DescribeTo(IDescription description)
        {
            description.AppendText($"a string containing \"{_expectedString}\"");
        }

        public void DescribeMismatch(string actual, IDescription description)
        {
            description.AppendText($"was \"{actual}\"");
        }
    }
}
