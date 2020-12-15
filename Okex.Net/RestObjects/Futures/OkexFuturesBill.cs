﻿using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters;
using Okex.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Okex.Net.Enums;

namespace Okex.Net.RestObjects
{
    public class OkexFuturesBill
    {
        /// <summary>
        /// ID of the bill record
        /// </summary>
        [JsonProperty("ledger_id")]
        public long LedgerId { get; set; }

        /// <summary>
        /// underlying，eg：BTC-USD BTC-USDT
        /// </summary>
        [JsonProperty("underlying")]
        public string Underlying { get; set; } = "";

        /// <summary>
        /// Amount
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Type of bill record
        /// </summary>
        [JsonProperty("type"), JsonConverter(typeof(FuturesBillTypeConverter))]
        public OkexFuturesBillType Type { get; set; }

        /// <summary>
        /// The time that the record is created
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Balance of positions opened. Balance positive if the open interest is long while negative if short. The balance will be '0' if the type and transfer is fee.
        /// </summary>
        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; } = "";

        /// <summary>
        /// If the type is generated by transaction, the order_id and instrument_id will be included in details,If the type is generated by transfer, the from and to will be included in details
        /// </summary>
        [JsonProperty("details")]
        public OkexFuturesBillDetails Details { get; set; } = new OkexFuturesBillDetails();

        [JsonProperty("from"), JsonConverter(typeof(FuturesRemittingAccountTypeConverter))]
        public OkexFuturesRemittingAccountType RemittingAccount { get; set; }

        [JsonProperty("to"), JsonConverter(typeof(FuturesReceivingAccountTypeConverter))]
        public OkexFuturesReceivingAccountType ReceivingAccount { get; set; } 
    }

    public class OkexFuturesBillDetails
    {
        /// <summary>
        /// Order ID
        /// </summary>
        [JsonProperty("order_id")]
        public long OrderId { get; set; }

        /// <summary>
        /// Contract ID, e.g. BTC-USD-180213
        /// </summary>
        [JsonProperty("instrument_id")]
        public string InstrumentId { get; set; } = "";

    }
}