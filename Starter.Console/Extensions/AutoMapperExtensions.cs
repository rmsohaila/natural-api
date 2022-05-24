using AutoMapper;
using System.Collections.Generic;

namespace Starter.Console.Extensions
{
    public static class AutoMapperExtensions
    {
        public static List<TDestination> MapList<TSource, TDestination>(this IMapper mapper, List<TSource> source)
        {
            return mapper.Map<List<TDestination>>(source);
        }
    }
}
