using AutoMapper;
using Processing.Core.Entities;
using Processing.Web.Models;

namespace Processing.Web.Mappings;

public class CommonMapping : Profile
{
	public CommonMapping()
	{
		CreateMap<Transaction, TransactionModel>();
	}
}