using System;
using Zoo.Core.Enums;

namespace Zoo.Api.ViewModels.Zebra.Create
{
    public class RequestViewModel
    {
        public string Name { get; set; }

        public Gender Gender { get; init; }

        public DateTime Birthday { get; init; }

        public int Stripes { get; init; }

        public int? EnclosureId { get; set; }
    }
}