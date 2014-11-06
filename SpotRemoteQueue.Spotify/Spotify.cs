using System;
using System.Collections.Generic;
using SpotRemoteQueue.LibSpotifyWrapper;
using SpotRemoteQueue.WebWrapper;
using SpotRemoteQueue.WebWrapper.Model;

namespace SpotRemoteQueue.Spotify
{
    public class Spotify
    {
        private readonly SpotifyApiLib _spotifyApi;
        private readonly SpotifyWeb _spotifyWeb;

        public Spotify()
        {
            _spotifyApi = new SpotifyApiLib();
            _spotifyWeb = new SpotifyWeb();
        }

        public void PlaySong(string spotifyUri)
        {
            _spotifyApi.PlaySong(spotifyUri);
        }

        public List<Artist> SearchArtists(string query)
        {
            _spotifyWeb.SearchArtist(query);

            return null;
        }
    }
}