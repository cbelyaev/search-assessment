// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace SearchModule.Mapping
{
    using AutoMapper;
    using Core.Items;
    using Items;

    /// <summary>
    ///     Represents a class with mapping profile for <see cref="DocumentItem"/>.
    /// </summary>
    internal class DocumentMappingProfile : Profile
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DocumentMappingProfile" /> class.
        /// </summary>
        public DocumentMappingProfile()
        {
            CreateMap<DocumentItem, FoundItem>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.ItemType, opt => opt.Ignore());
        }
    }
}