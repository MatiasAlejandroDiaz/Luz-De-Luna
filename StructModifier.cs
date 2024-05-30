namespace UnitsLDL
{
    public struct StructModifier
    {
        public float ValueModd;
        public string DescModd;

        public readonly bool Equals(StructModifier other) => (ValueModd == other.ValueModd && DescModd == other.DescModd);
    }
}

