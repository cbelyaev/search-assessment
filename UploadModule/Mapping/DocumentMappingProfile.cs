// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace UploadModule.Mapping
{
    using AutoMapper;
    using Core.Items;

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
            CreateMap<BuildingItem, DocumentItem>();
            CreateMap<CompanyItem, DocumentItem>()
                .ForMember(x => x.FormerName, opt => opt.Ignore())
                .ForMember(x => x.Address, opt => opt.Ignore())
                .ForMember(x => x.City, opt => opt.Ignore());

            CreateMap<DocumentItem, BuildingItem>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Latitude, opt => opt.Ignore())
                .ForMember(x => x.Longitude, opt => opt.Ignore());

            CreateMap<DocumentItem, CompanyItem>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}