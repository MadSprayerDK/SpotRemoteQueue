using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotRemoteQueue.LibSpotifyWrapper.API;
using sp_error = SpotRemoteQueue.LibSpotifyWrapper.API.Error.sp_error;

namespace SpotRemoteQueue.LibSpotifyWrapper
{
    public sealed class SpotifyException : Exception
    {
        private readonly string _message;

        public SpotifyException(sp_error error)
        {
            switch (error)
            {
                case sp_error.API_INITIALIZATION_FAILED:
                    _message = "Initialization of library failed - are cache locations etc. valid?";
                    break;

                case sp_error.APPLICATION_BANNED:
                    _message = "This application is no longer allowed to use the Spotify service.";
                    break;

                case sp_error.APPLICATION_KEY:
                    _message = "The application key is invalid.";
                    break;

                case sp_error.BAD_API_VERSION:
                    _message = "The library version targeted does not match the one you claim you support.";
                    break;

                case sp_error.BAD_USERNAME_OR_PASSWORD:
                    _message = "Login failed because of bad username and/or password.";
                    break;

                case sp_error.BAD_USER_AGENT:
                    _message = "The user agent string is invalid or too long.";
                    break;

                case sp_error.CANT_OPEN_TRACE_FILE:
                    _message = "Unable to open trace file.";
                    break;

                case sp_error.CLIENT_TOO_OLD:
                    _message = "Client is too old, library will need to be updated.";
                    break;

                case sp_error.INBOX_IS_FULL:
                    _message = "Target inbox is full.";
                    break;

                case sp_error.INDEX_OUT_OF_RANGE:
                    _message = "Index out of range.";
                    break;

                case sp_error.INVALID_DEVICE_ID:
                    _message = "Invalid device ID";
                    break;

                case sp_error.INVALID_INDATA:
                    _message = "Input data was either missing or invalid.";
                    break;

                case sp_error.IS_LOADING:
                    _message = "The resource is currently loading.";
                    break;

                case sp_error.MISSING_CALLBACK:
                    _message = "No valid callback registered to handle events.";
                    break;

                case sp_error.NETWORK_DISABLED:
                    _message = "Network disabled.";
                    break;

                case sp_error.NO_CACHE:
                    _message = "Cache is not enabled.";
                    break;

                case sp_error.NO_CREDENTIALS:
                    _message = "No credentials are stored.";
                    break;

                case sp_error.NO_STREAM_AVAILABLE:
                    _message = "Could not find any suitable stream to play.";
                    break;

                case sp_error.NO_SUCH_USER:
                    _message = "Requested user does not exist.";
                    break;

                case sp_error.OFFLINE_DISK_CACHE:
                    _message = "Disk cache is full so no more tracks can be downloaded to offline mode.";
                    break;

                case sp_error.OFFLINE_EXPIRED:
                    _message = "Offline key has expired, the user needs to go online again.";
                    break;

                case sp_error.OFFLINE_LICENSE_ERROR:
                    _message = "The Spotify license server does not respond correctly.";
                    break;

                case sp_error.OFFLINE_LICENSE_LOST:
                    _message = "The license for this device has been lost. Most likely because the user used offline on three other device.";
                    break;

                case sp_error.OFFLINE_NOT_ALLOWED:
                    _message = "This user is not allowed to use offline mode.";
                    break;

                case sp_error.OFFLINE_TOO_MANY_TRACKS:
                    _message = "Reached the device limit for number of tracks to download.";
                    break;

                case sp_error.OK:
                    _message = "No errors encountered.";
                    break;

                case sp_error.OTHER_PERMANENT:
                    _message = "Some other error occurred, and it is permanent (e.g. trying to relogin will not help).";
                    break;

                case sp_error.OTHER_TRANSIENT:
                    _message = "A transient error occurred.";
                    break;

                case sp_error.PERMISSION_DENIED:
                    _message = "Requested operation is not allowed.";
                    break;

                case sp_error.TRACK_NOT_PLAYABLE:
                    _message = "The track specified for playing cannot be played.";
                    break;

                case sp_error.UNABLE_TO_CONTACT_SERVER:
                    _message = "Cannot connect to the Spotify backend system.";
                    break;

                case sp_error.USER_BANNED:
                    _message = "The specified username is banned.";
                    break;

                case sp_error.USER_NEEDS_PREMIUM:
                    _message = "The specified user needs a premium account.";
                    break;

                default:
                    _message = "Unknown error happend";
                    break;
            }

            HResult = (int)error.GetTypeCode();
            HelpLink = "https://developer.spotify.com/docs/libspotify/12.1.51/group__error.html";
        }

        public override string Message
        {
            get { return _message; }
        }
    }
}
