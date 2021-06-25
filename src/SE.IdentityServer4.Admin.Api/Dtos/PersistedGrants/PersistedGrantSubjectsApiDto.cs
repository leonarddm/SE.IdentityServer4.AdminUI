using System.Collections.Generic;

namespace SE.IdentityServer4.Admin.Api.Dtos.PersistedGrants
{
    public class PersistedGrantSubjectsApiDto
    {
        public PersistedGrantSubjectsApiDto()
        {
            PersistedGrants = new List<PersistedGrantSubjectApiDto>();
        }        

        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public List<PersistedGrantSubjectApiDto> PersistedGrants { get; set; }
    }
}







