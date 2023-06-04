using WAW.API.Shared.Domain.Repositories;
using WAW.API.Subscriptions.Domain.Models;
using WAW.API.Subscriptions.Domain.Repositories;
using WAW.API.Subscriptions.Domain.Services;
using WAW.API.Subscriptions.Domain.Services.Communication;

namespace WAW.API.Subscriptions.Services;

public class PlanSubscriptionService : IPlanSubscriptionService {

  private readonly IPlanSubscriptionRepository repository;
  private readonly IUnitOfWork unitOfWork;

  public PlanSubscriptionService(IPlanSubscriptionRepository repository, IUnitOfWork unitOfWork) {
    this.repository = repository;
    this.unitOfWork = unitOfWork;
  }

  public Task<IEnumerable<PlanSubscription>> ListAll() {
    return repository.ListAll();
  }


  public async Task<PlanSubscriptionResponse> Create(PlanSubscription planSubscription) {
    try {
      await repository.Add(planSubscription);
      await unitOfWork.Complete();
      return new PlanSubscriptionResponse(planSubscription);

    } catch (Exception e) {
      return new PlanSubscriptionResponse($"An error occurred while saving the plan subscription: {e.Message}");
    }
  }

  public async Task<PlanSubscriptionResponse> Delete(long id) {
    var current = await repository.FindById(id);
    if (current == null) {
      return new PlanSubscriptionResponse("Plan Subscription not found");
    }

    try {
      repository.Remove(current);
      await unitOfWork.Complete();
      return new PlanSubscriptionResponse(current);

    } catch (Exception e) {
      return new PlanSubscriptionResponse($"An error occurred while deleting the plan subscription: {e.Message}");
    }
  }
  public async Task<PlanSubscriptionResponse> Update(long id, PlanSubscription planSubscription) {
    var current = await repository.FindById(id);
    if (current == null)
      return new PlanSubscriptionResponse("Plan Subscription not found");

    planSubscription.CopyTo(current);

    try {
      repository.Update(current);
      await unitOfWork.Complete();
      return new PlanSubscriptionResponse(planSubscription);

    } catch (Exception e) {
      return new PlanSubscriptionResponse($"An error occurred while updating the plan subscription: {e.Message}");
    }
  }
}
