using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Processing.Core.Entities;
using Processing.Core.Enums;
using Processing.Importer.Entities;
using Processing.Importer.Enums;

namespace Processing.Core.Mappings;

public class CommonMapping : Profile
{
	public CommonMapping()
	{
		CreateMap<CsvTransaction, Transaction>();
		CreateMap<CsvImporterResponseStatus, TransactionStatus>()
			.ConvertUsingEnumMapping(opt => opt
				.MapValue(CsvImporterResponseStatus.Approved, TransactionStatus.A)
				.MapValue(CsvImporterResponseStatus.Failed, TransactionStatus.R)
				.MapValue(CsvImporterResponseStatus.Finished, TransactionStatus.D)
			)
			.ReverseMap();
		
		CreateMap<XmlTransaction, Transaction>();
		CreateMap<XmlImporterResponseStatus, TransactionStatus>()
			.ConvertUsingEnumMapping(opt => opt
				.MapValue(XmlImporterResponseStatus.Approved, TransactionStatus.A)
				.MapValue(XmlImporterResponseStatus.Rejected, TransactionStatus.R)
				.MapValue(XmlImporterResponseStatus.Done, TransactionStatus.D)
			)
			.ReverseMap();
	}
}