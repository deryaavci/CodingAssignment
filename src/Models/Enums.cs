namespace CodingAssignment.src.Models
{
    public enum Stolenness { non, proximity, all, stolen };

    public enum CycleType
    {
        Bike,
        Tandem,
        Unicycle,
        Tricycle,
        Stroller,
        Recumbent,
        BikeTrailer,
        Wheelchair,
        CargoBikeFrontStorage,
        TallBike,
        PennyFarthing,
        CargoBikeRear,
        CargoTricycleFrontStorage,
        CargoTricycleRearStorage,
        TrailBehind,
        PediCab,
        EScooter,
        PersonalMobility,
        NonEScooter,
        NonESkateboard,
        EMotorcycle
    }

    public enum PropulsionType
    {
        FootPedal,
        PedalAssist,
        ElectricThrottle,
        PedalAssistAndThrottle,
        HandCycle,
        HumanPoweredNotByPedals
    }
}
