using Newtonsoft.Json.Linq;
using System.Text;

namespace rcsdk_test
{
    //rcsdk callbacks
    //public delegate void ConnectAckEventHandler(string json_str);
    class connect_ack_callback_delegate
    {
        public static void connect_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
            string result = (string)jobj["result"];
            string userId = (string)jobj["userId"];
            int err_code = (int)jobj["err_code"];
        }
    }

    //public delegate void BlacklistInfoListenerEventHandler(string json_str);
    class black_list_callback_delegate
    {
        public static void black_list_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void public delegate void PublishAckListenerEventHandler(string json_str);
    class remove_member_from_discussion_callback_delegate
    {
        public static void remove_member_from_discussion_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void public delegate void PublishAckListenerEventHandler(string json_str);
    class send_message_callback_delegate
    {
        public static void send_message_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void PublishAckListenerEventHandler(string json_str);
    class sync_groups_callback_delegate
    {
        public static void sync_groups_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void PublishAckListenerEventHandler(string json_str);
    class join_group_callback_delegate
    {
        public static void join_group_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void PublishAckListenerEventHandler(string json_str);
    class quit_group_callback_delegate
    {
        public static void quit_group_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void PublishAckListenerEventHandler(string json_str);
    class set_user_data_callback_delegate
    {
        public static void set_user_data_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void PublishAckListenerEventHandler(string json_str);
    class remove_push_setting_callback_delegate
    {
        public static void remove_push_setting_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void PublishAckListenerEventHandler(string json_str);
    class quit_discussion_callback_delegate
    {
        public static void quit_discussion_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void BlacklistInfoListenerEventHandler(string json_str);
    class set_block_push_callback_delegate
    {
        public static void set_block_push_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void BlacklistInfoListenerEventHandler(string json_str);
    class get_block_push_callback_delegate
    {
        public static void get_block_push_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void UserInfoListeneEventHandler(string json_str);
    class get_user_info_callback_delegate
    {
        public static void get_userinfo_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void CreateDiscussionListenerEventHandler(string json_str);
    class create_invite_discussion_callback_delegate
    {
        public static void create_invite_discussion_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
            string discussion_id = (string)jobj["discussionId"];
        }
    }
    //public delegate void PublishAckListenerEventHandler(string json_str);
    class invite_member_todiscussion_callback_delegate
    {
        public static void invite_to_discussion_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void PublishAckListenerEventHandler(string json_str);
    class sub_scribe_account_callback_delegate
    {
        public static void sub_scribe_account_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void PublishAckListenerEventHandler(string json_str);
    class join_chatroom_callback_delegate
    {
        public static void join_chatroom_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    // public delegate void PublishAckListenerEventHandler(string json_str);
    class quit_chatroom_callback_delegate
    {
        public static void quit_chatroom_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    // public delegate void PublishAckListenerEventHandler(string json_str);
    class add_to_black_callback_delegate
    {
        public static void add_to_black_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    // public delegate void PublishAckListenerEventHandler(string json_str);
    class remove_from_black_callback_delegate
    {
        public static void remove_from_black_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    // public delegate void PublishAckListenerEventHandler(string json_str);
    class set_invite_status_callback_delegate
    {
        public static void set_invite_status_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void PublishAckListenerEventHandler(string json_str);
    class rename_discussion_callback_delegate
    {
        public static void rename_discussion_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void CreateDiscussionListenerEventHandler(string json_str);
    class get_user_data_callback_delegate
    {
        public static void get_user_data_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void ImageListenerEventHandler(string json_str);
    class send_file_with_url_callback_delegate
    {
        public static void send_file_with_url_process_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
        public static void send_file_with_url_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
            string result = (string)jobj["result"];
            if(result == "failed")
            {
                return;
            }
            string url = (string)jobj["url"];
        }
    }

    //public delegate void ImageListenerEventHandler(string json_str);
    class down_file_with_url_callback_delegate
    {
        public static void down_file_with_url_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }

        public static void down_file_with_url_process_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    // public delegate void PublishAckListenerEventHandler(string json_str);
    class add_push_setting_callback_delegate
    {
        public static void add_push_setting_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    // public delegate void PushSettingListenerEventHandler(string json_str);
    class query_push_setting_callback_delegate
    {
        public static void query_push_setting_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    // public delegate void EnvirtmentCallbackEventHandler(string json_str);
    class envirtment_change_callback_delegate
    {
        public static void envirtment_change_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void MessageInfoEventHandler(string json_str);
    class get_paged_messageex_callback_delegate
    {
        public static unsafe void get_paged_messagex_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void MessageInfoEventHandler(string json_str);
    class get_message_by_id_callback_delegate
    {
        public static unsafe void get_message_by_id_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void MessageInfoEventHandler(string json_str);
    class search_messageex_callback_delegate
    {
        public static unsafe void search_messagex_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void MessageListenerEventHandler(string json_str);
    class set_message_listener_callback_delegate
    {
        public static void set_message_listener_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
            string msg_json_str = (string)jobj["m_Message"];
            JObject msg_jobj = JObject.Parse(msg_json_str);
            string content_str = (string)msg_jobj["content"];
        }
    }

    //public delegate void ExceptionListenerEventHandler(string json_str);
    class exception_listener_callback_delegate
    {
        public static void exception_listener_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void MessageInfoEventHandler(string json_str);
    class get_his_msg_callback_delegate
    {
        public static unsafe void get_his_msg_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void DataBufferEventHander(string json_str);
    class get_data_buffer_delegate
    {
        public static unsafe void get_data_buffer_delegate_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void AccountInfoEventHandler(string json_str);
    class load_account_info_callback_delegate
    {
        public static unsafe void load_account_info_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }
    //public delegate void DiscussionInfoListenerEventHandler(string json_str);
    class discussion_info_callback_delegate
    {
        public static void discussion_info_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void DisInfoSyncEventHandler(string json_str);
    class get_dis_info_sync_callback_delegate
    {
        public static void get_dis_info_sync_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void PublishAckListenerEventHandler(string json_str);
    class account_listener_callback_delegate
    {
        public static void account_listener_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void UserInfoEventHandler(string json_str);
    class user_info_ex_sync_callback_delegate
    {
        public static void user_info_ex_sync_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void ConversationInfoEventHandler(string json_str);
    class get_con_ex_callback_delegate
    {
        public static void get_con_ex_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }
    //public delegate void ConversationInfoEventHandler(string json_str);
    class get_con_listex_callback_delegate
    {
        public static unsafe void get_con_listex_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }
    //public delegate void ConversationInfoEventHandler(string json_str);
    class get_topcon_listex_callback_delegate
    {
        public static unsafe void get_topcon_listex_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void MessageListenerEventHandler(string json_str);
    class load_history_message_callback_delegate
    {
        public static void load_his_msg_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void NaviDataListenerEventHandler(string json_str);
    class navi_data_listener_callback_delegate
    {
        public static void navi_data_listener_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //public delegate void TokenListenerEventHandler(string json_str);

    class token_listener_callback_delegate
    {
        public static void token_listener_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }

    //ChatroomInfoListenerEventHandler
    class chat_room_info_listener_callback_delegate
    {
        public static void chat_room_info_listener_call_back(string json_str)
        {
            //在这里添加通知UI层代码
            byte[] buffer1 = Encoding.UTF8.GetBytes(json_str);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Unicode.GetString(buffer2, 0, buffer2.Length);
            JObject jobj = JObject.Parse(strBuffer);
        }
    }
}
