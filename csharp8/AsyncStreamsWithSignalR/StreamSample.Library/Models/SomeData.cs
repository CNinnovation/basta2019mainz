namespace StreamSample.Models
{
    public struct SomeData
    {
        public SomeData(int value) => Value = value;
        public int Value { get; }

        public override string ToString() => Value.ToString();
    }
}
