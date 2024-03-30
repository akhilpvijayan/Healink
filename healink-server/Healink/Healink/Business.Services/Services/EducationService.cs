using AutoMapper;
using Healink.Business.Services.Dto;
using Healink.Data;
using Healink.Entities;
using Microsoft.Extensions.Options;
using MimeKit.Encodings;

namespace Healink.Business.Services.Services
{
    public class EducationService: IEducationService
    {
        #region properties
        private readonly DataContext _context;
        #endregion

        #region constructor
        public EducationService(DataContext context)
        {
            this._context = context;
        }
        #endregion
        #region public functions
        public async Task<bool> AddUserEducation(List<UserEducationDto> userEducation, long userId)
        {
            try
            {
                foreach (UserEducationDto education in userEducation)
                {
                    var educationEntity = new Education
                    {
                        Institution = education.Institution,
                        Degree = education.Degree,
                        FieldOfStudy = education.FieldOfStudy,
                        GraduationstartDate = education.GraduationStartDate,
                        GraduationEndDate = education.GraduationEndDate,
                        GraduationDescription = education.GraduationDescription,
                        UserId = userId,
                        CreatedBy = userId,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = userId,
                        ModifiedDate = DateTime.Now,
                        OrgId = education.OrgId == 0 ? null : education.OrgId,
                    };
                    await _context.Educations.AddAsync(educationEntity);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        }
}
