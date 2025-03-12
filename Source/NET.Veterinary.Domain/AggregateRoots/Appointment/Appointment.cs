using NET.Veterinary.Domain.ObjectValues;

namespace NET.Veterinary.Domain.AggregateRoots.Appointment
{
    public sealed class Appointment
    {
        public int Id { get; private set; } 
        
        public TimestampNoTimeZone DateSelect { get; private set; }
        
        public CompleteName CompleteName { get; private set; }
        
        public Identification Identification { get; private set; }
        
        public bool DidAssist { get; private set; }
        
        public Appointment(int id, TimestampNoTimeZone dateSelect, CompleteName completeName, Identification identification, bool didAssist)
        {
            this.Id = id; 
            this.DateSelect = dateSelect;
            this.CompleteName = completeName;
            this.Identification = identification;
            this.DidAssist = didAssist;
        }
        
        private Appointment(){}
    }
}