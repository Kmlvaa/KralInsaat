namespace KralInsaat.Common.ValueObjects
{
    public class Coordinates
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        private Coordinates() { }

        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Coordinates other)
                return false;

            return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
        }

        public override int GetHashCode() => HashCode.Combine(Latitude, Longitude);
    }
}