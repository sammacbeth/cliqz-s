using Newtonsoft.Json.Linq;
using ReactNative.UIManager.Events;
using System;

namespace CliqzS
{
    class WebViewNewWindowRequestedEvent : Event
    {
        private readonly string _type;

        private readonly string _url;
        private readonly string _referrer;

        public WebViewNewWindowRequestedEvent(
            int viewTag, 
            string url, 
            string referrer
            )
            : base(viewTag, TimeSpan.FromTicks(Environment.TickCount))
        {
            _url = url;
            _referrer = referrer;
        }

        public override string EventName
        {
            get
            {
                return "newWindowRequested";
                
            }
        }

        public override void Dispatch(RCTEventEmitter eventEmitter)
        {
            var eventData = new JObject
            {
                { "target", ViewTag },
                { "url", _url },
                { "referrer", _referrer },
            };

            eventEmitter.receiveEvent(ViewTag, EventName, eventData);
        }
    }
}
