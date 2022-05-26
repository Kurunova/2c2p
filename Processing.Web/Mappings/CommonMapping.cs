using AutoMapper;
using Processing.Core.Entities;
using Processing.Core.Filers;
using Processing.Web.Models;

namespace Processing.Web.Mappings;

public class CommonMapping : Profile
{
	public CommonMapping()
	{
		CreateMap<Transaction, TransactionModel>();
		CreateMap<TransactionRequest, TransactionSearchRequestData>();
	}
}