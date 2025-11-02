using Microsoft.AspNetCore.Mvc;
using SE4458_Playlist.Models;


namespace SE4458_Playlist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistController : ControllerBase
    {
        private static readonly List<Song> Songs = [];
        private static int id = 1;

        [HttpGet]
        public IActionResult GetSongsByNameOrArtist([FromQuery] string input)
        {
            var results = string.IsNullOrEmpty(input)
                ? Songs
                : Songs.Where(song =>
                    song.Name.Contains(input, StringComparison.OrdinalIgnoreCase) || song.Artist.Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();

            return Ok(results);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetSongById(int id)
        {
            var song = Songs.FirstOrDefault(s => s.Id == id);
            if (song == null) return NotFound();
            return Ok(song);
        }


        [HttpPost]
        public IActionResult AddSong([FromBody] Song song)
        {
            song.Id = id++ ;
            Songs.Add(song);
            return CreatedAtAction(nameof(GetSongById), new { id = song.Id }, song);
        }


        [HttpDelete("byname/{name}")]
        public IActionResult DeleteSongByName(string name)
        {
            var song = Songs.FirstOrDefault(s =>
                s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (song == null)
                return NotFound(new { message = $"Can not found the song with name: {name}. Try Again." });

            Songs.Remove(song);
            return Ok(new { message = $"Deleted {song.Name} by {song.Artist}." });
        }
    }
}
