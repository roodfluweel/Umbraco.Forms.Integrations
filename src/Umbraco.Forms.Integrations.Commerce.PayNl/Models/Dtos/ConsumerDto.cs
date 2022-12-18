﻿using System.Xml.Serialization;

namespace Umbraco.Forms.Integrations.Commerce.PayNl.Models.Dtos
{
    public class ConsumerDto : ResponseDto
    {
        [XmlElement("consumer_id")]
        public string Id { get; set; }

        [XmlElement("email")] 
        public string Email { get; set; }
    }
}
