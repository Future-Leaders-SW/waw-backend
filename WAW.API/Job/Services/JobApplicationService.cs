using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Job.Domain.Models;
using WAW.API.Job.Domain.Repositories;
using WAW.API.Job.Domain.Services;
using WAW.API.Job.Domain.Services.Communication;
using WAW.API.Job.Resources;
using WAW.API.Shared.Domain.Repositories;

namespace WAW.API.Job.Services;

public class JobApplicationService : IJobApplicationService {
  private readonly IJobApplicationRepository _jobApplicationRepository;
  private readonly IUnitOfWork _unitOfWork; 


  public JobApplicationService(IJobApplicationRepository jobApplicationRepository, IUnitOfWork unitOfWork, IMapper mapper) {
    _jobApplicationRepository = jobApplicationRepository;
    _unitOfWork = unitOfWork; 
  }

  public async Task<IEnumerable<JobApplication>> ListAll() {
    return await _jobApplicationRepository.ListAll();
  }
  public async Task<IEnumerable<Offer>> GetOffersByUserId(long userId) {
    var jobApplications = await _jobApplicationRepository.GetByUserId(userId);
    return jobApplications.Select(j => j.Offer).ToList();
}
  public async Task<JobApplicationResponse> Create(JobApplication request) {
    try {
      await _jobApplicationRepository.Add(request);
      await _unitOfWork.Complete();

      return new JobApplicationResponse(request);
    } catch (Exception ex) {
      return new JobApplicationResponse($"An error occurred when saving the job application: {ex.Message}");
    }
  }

  

  public async Task<JobApplicationResponse> Update(long id, JobApplication request) {
    var existingJobApplication = await _jobApplicationRepository.GetById(id);

    if (existingJobApplication == null) {
      return new JobApplicationResponse("Job application not found.");
    }

    request.CopyTo(existingJobApplication);
    if (existingJobApplication.UserId != request.UserId) {
      return new JobApplicationResponse("Unauthorized");
    }


    try {
      _jobApplicationRepository.Update(existingJobApplication);
      await _unitOfWork.Complete();

      return new JobApplicationResponse(existingJobApplication);
    } catch (Exception ex) {
      return new JobApplicationResponse($"An error occurred when updating the job application: {ex.Message}");
    }
  }

  public async Task<JobApplicationResponse> Delete(long id) {
    var existingJobApplication = await _jobApplicationRepository.GetById(id);

    if (existingJobApplication == null) {
      return new JobApplicationResponse("Job application not found.");
    }

    try {
      _jobApplicationRepository.Remove(existingJobApplication);
      await _unitOfWork.Complete();
      return new JobApplicationResponse(existingJobApplication);
    } catch (Exception e) {
      return new JobApplicationResponse($"An error occurred while deleting the job application: {e.Message}");
    }
  }


}
