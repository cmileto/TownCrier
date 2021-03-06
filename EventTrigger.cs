﻿using System;
using System.Text;

namespace TownCrier
{
    class EventTrigger
    {
        public string Event;
        public Webhook Webhook;
        public string MessageFormat;
        public bool Enabled;

        public EventTrigger(string evt, Webhook webhook, string messageFormat, bool enabled)
        {
            Event = evt;
            Webhook = webhook;
            MessageFormat = messageFormat;
            Enabled = enabled;
        }

        public override string ToString()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("EventTrigger: On '");
                sb.Append(Event);
                sb.Append("', trigger webhook '");
                sb.Append(Webhook.Name);
                sb.Append("' with message: '");
                sb.Append(MessageFormat);
                sb.Append("'. Currently ");
                sb.Append(Enabled ? "Enabled" : "Disabled");
                sb.Append(".");

                return sb.ToString();

            }
            catch (Exception ex)
            {
                Util.LogError(ex);

                return "Failed to print EventTrigger.";
            }
        }

        public string ToSetting()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("eventtrigger\t");
                sb.Append(Event);
                sb.Append("\t");
                sb.Append(Webhook.Name);
                sb.Append("\t");
                sb.Append(MessageFormat);
                sb.Append("\t");
                sb.Append(Enabled);

                return sb.ToString();
            }
            catch (Exception ex)
            {
                Util.LogError(ex);

                return "Failed to print EventTrigger.";
            }
        }

        public void Enable()
        {
            Enabled = true;
        }

        public void Disable()
        {
            Enabled = false;
        }
    }
}
