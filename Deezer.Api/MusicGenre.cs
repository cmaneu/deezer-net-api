namespace Deezer.Api
{
    /// <summary>
    /// Represents the music genres. Created from http://api.deezer.com/genre.
    /// Note: I'm not convinced that such a "static" enum is an appropriate way
    /// to handle that (because they can change within time). However: 
    /// - The genres are not created each day, 
    /// - An enum is a convenient way to get that info for the developers.
    /// </summary>
    public enum MusicGenre
    {
        French = 1,
        Pop = 2,
        Alternative = 3,
        Rock = 4,
        Metal = 5,
        HipHop = 9,
        Electro = 6,
        Dance = 7,
        RnbSoul = 8,
        WorldMusic = 10,
        Jazz = 11,
        Soundtrack = 13
    }
}