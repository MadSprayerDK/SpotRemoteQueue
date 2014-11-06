using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using SpotRemoteQueue.LibSpotifyWrapper.API;

namespace SpotRemoteQueue.LibSpotifyWrapper
{
    public class SpotifyApiLib
    {
        private IntPtr _sessionPtr;

        public SpotifyApiLib()
        {
            var appKey = File.ReadAllBytes("spotify_appkey.key");

            var callbacks = new Session.sp_session_callbacks()
                        {
                            connection_error = Marshal.GetFunctionPointerForDelegate(fn_connection_error_delegate),
                            end_of_track = Marshal.GetFunctionPointerForDelegate(fn_end_of_track_delegate),
                            get_audio_buffer_stats = Marshal.GetFunctionPointerForDelegate(fn_get_audio_buffer_delegate),
                            log_message = Marshal.GetFunctionPointerForDelegate(fn_log_message),
                            logged_in = Marshal.GetFunctionPointerForDelegate(fn_logged_in),
                            logged_out = Marshal.GetFunctionPointerForDelegate(fn_logged_out),
                            message_to_user = Marshal.GetFunctionPointerForDelegate(fn_message_to_user),
                            metadata_updated = Marshal.GetFunctionPointerForDelegate(fn_metadata_updated),
                            music_delivery = Marshal.GetFunctionPointerForDelegate(fn_music_delivery),
                            notify_main_thread = Marshal.GetFunctionPointerForDelegate(fn_notify_main_thread),
                            offline_status_updated = Marshal.GetFunctionPointerForDelegate(fn_offline_status_updated),
                            play_token_lost = Marshal.GetFunctionPointerForDelegate(fn_play_token_lost),
                            start_playback = Marshal.GetFunctionPointerForDelegate(fn_start_playback),
                            stop_playback = Marshal.GetFunctionPointerForDelegate(fn_stop_playback),
                            streaming_error = Marshal.GetFunctionPointerForDelegate(fn_streaming_error),
                            userinfo_updated = Marshal.GetFunctionPointerForDelegate(fn_userinfo_updated)
                        };

            IntPtr callbackPtr = Marshal.AllocHGlobal(Marshal.SizeOf(callbacks));
            Marshal.StructureToPtr(callbacks, callbackPtr, true);

            var config = new Session.sp_session_config
                         {
                             api_version = Session.SPOTIFY_API_VERSION,
                             application_key = Marshal.AllocHGlobal(appKey.Length),
                             application_key_size = appKey.Length,
                             cache_location = "/tmp",
                             callbacks = callbackPtr,
                             compress_playlists = true,
                             dont_save_metadata_for_playlists = false,
                             initially_unload_playlists = false,
                             settings_location = "/tmp",
                             user_agent = "SpotRemoteQueue"
                         };

            Marshal.Copy(appKey, 0, config.application_key, appKey.Length);

            CreateSession(config);
        }

        public SpotifyApiLib(Session.sp_session_config config)
        {
            CreateSession(config);
        }

        private void CreateSession(Session.sp_session_config config)
        {
            var error = Session.sp_session_create(ref config, out _sessionPtr);

            if (error != Error.sp_error.OK)
            {
                throw new SpotifyException(error);
            }
        }

        ~SpotifyApiLib()
        {
            Session.sp_session_release(_sessionPtr);
        }

        public bool PlaySong()
        {
            throw new NotImplementedException();
        }

        public bool PauseSong()
        {
            throw new NotImplementedException();
        }

        public bool NextSong()
        {
            throw new NotImplementedException();
        }

        public bool PrefetchSong(string spotifyUri)
        {
            throw new NotImplementedException();
        }

        public bool PlaySong(string spotifyUri)
        {
            throw new NotImplementedException();
        }

        #region Callback

            #region Connection Error

                private delegate void connection_error_delegate(IntPtr sessionPtr, Error.sp_error error);

                private static void connection_error(IntPtr sessionPtr, Error.sp_error error)
                {
                    // TODO: Somthing
                }

                private static connection_error_delegate fn_connection_error_delegate = connection_error;

            #endregion
            #region End Of Track

                private delegate void end_of_track_delegate(IntPtr sessionPtr);

                private static void end_of_track(IntPtr sessionPtr)
                {
                    // TODO: Somthing
                }

                private static end_of_track_delegate fn_end_of_track_delegate = end_of_track;

            #endregion
            #region Get Audio Buffer Stats

                private delegate void get_audio_buffer_stats_delegate(IntPtr sessionPtr, IntPtr statsPtr);

                private static void get_audio_buffer_stats(IntPtr sessionPtr, IntPtr statPtr)
                {
                    // TODO: Somthing
                }

                private static get_audio_buffer_stats_delegate fn_get_audio_buffer_delegate = get_audio_buffer_stats;

            #endregion
            #region Log Message

                private delegate void log_message_delegate(IntPtr sessionPtr, string message);

                private static void log_message(IntPtr sessionPtr, string message)
                {
                    // TODO: Somthing
                }

                private static log_message_delegate fn_log_message = log_message;

            #endregion
            #region Logged In

                private delegate void logged_in_delegate(IntPtr sessionPtr, Error.sp_error error);

                private static void logged_in(IntPtr sessionPtr, Error.sp_error error)
                {
                    // TODO: Somthing
                }

                private static logged_in_delegate fn_logged_in = logged_in;

            #endregion
            #region Logged Out

                private delegate void logged_out_delegate(IntPtr sessionPtr);

                private static void logged_out(IntPtr sessionPtr)
                {
                    // TODO: Somthing
                }

                private static logged_out_delegate fn_logged_out = logged_out;

            #endregion
            #region Message To User

                private delegate void message_to_user_delegate(IntPtr sessionPtr, string message);

                private static void message_to_user(IntPtr sessionPtr, string message)
                {
                    // TODO: Somthing
                }

                private static message_to_user_delegate fn_message_to_user = message_to_user;

            #endregion
            #region Metadata Updated

                private delegate void metadata_updated_delegate(IntPtr sessionPtr);

                private static void metadata_updated(IntPtr sessionPtr)
                {
                    // TODO: Somthing
                }

                private static metadata_updated_delegate fn_metadata_updated = metadata_updated;

            #endregion
            #region Music Delivery

                private delegate int music_delivery_delegate(IntPtr sessionPtr, IntPtr formatPtr, IntPtr framesPtr, int num_frames);

                private static int music_delivery(IntPtr sessionPtr, IntPtr formatPtr, IntPtr framesPtr, int num_frames)
                {
                    // TODO: Somthing
                    return 0;
                }

                private static music_delivery_delegate fn_music_delivery = music_delivery;

            #endregion
            #region Notify Main Thread

                private delegate void notify_main_thread_delegate(IntPtr sessionPtr);

                private static void notify_main_thread(IntPtr sessionPtr)
                {
                    // TODO: Somthing
                }

                private static notify_main_thread_delegate fn_notify_main_thread = notify_main_thread;

            #endregion
            #region Offline Status Updated

                private delegate void offline_status_updated_delegate(IntPtr sessionPtr);

                private static void offline_status_updated(IntPtr sessionPtr)
                {
                    // TODO: Somthing
                }

                private static offline_status_updated_delegate fn_offline_status_updated = offline_status_updated;

            #endregion
            #region Play Token Lost

                private delegate void play_token_lost_delegate(IntPtr sessionPtr);

                private static void play_token_lost(IntPtr sessionPtr)
                {
                    // TODO: Somthing
                }

                private static play_token_lost_delegate fn_play_token_lost = play_token_lost;

            #endregion
            #region Start Playback

                private delegate void start_playback_delegate(IntPtr sessionPtr);

                private static void start_playback(IntPtr sessionPtr)
                {
                    // TODO: Somthing
                }

                private static start_playback_delegate fn_start_playback = start_playback;

            #endregion
            #region Stop Playback

                private delegate void stop_playback_delegate(IntPtr sessionPtr);

                private static void stop_playback(IntPtr sessionPtr)
                {
                    // TODO: Somthing
                }

                private static stop_playback_delegate fn_stop_playback = stop_playback;

            #endregion
            #region Streaming Error

                private delegate void streaming_error_delegate(IntPtr sessionPtr, Error.sp_error error);

                private static void streaming_error(IntPtr sessionPtr, Error.sp_error error)
                {
                    // TODO: Somthing
                }

                private static streaming_error_delegate fn_streaming_error = streaming_error;

            #endregion
            #region Userinfo Updated

                private delegate void userinfo_updated_delegate(IntPtr sessionPtr);

                private static void userinfo_updated(IntPtr sessionPtr)
                {
                    // TODO: Somthing
                }

                private static userinfo_updated_delegate fn_userinfo_updated = userinfo_updated;

            #endregion

        #endregion
    }
}
