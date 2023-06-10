using WAW.API.Shared.Domain.Repositories;
using WAW.API.Subscriptions.Domain.Models;
using WAW.API.Subscriptions.Domain.Repositories;
using WAW.API.Subscriptions.Domain.Services;
using WAW.API.Subscriptions.Domain.Services.Communication;

namespace WAW.API.Subscriptions.Services;

public class SubscriptionService :ISubscriptionService{
  private readonly ISubscriptionRepository repository;
  private readonly IUnitOfWork unitOfWork;

  public SubscriptionService(ISubscriptionRepository repository, IUnitOfWork unitOfWork) {
    this.repository = repository;
    this.unitOfWork = unitOfWork;
  }

  public Task<IEnumerable<Subscription>> ListAll() {
    return repository.ListAll();
  }

  public async Task<SubscriptionResponse> Create (Subscription subscription){
    try {
      await repository.Add(subscription);
      await unitOfWork.Complete();
      return new SubscriptionResponse(subscription);

    } catch (Exception e) {
      return new SubscriptionResponse($"An error occurred while saving the subscription: {e.Message}");
    }
  }

  public async Task<SubscriptionResponse> Update(long id, Subscription subscription) {

    var current = await repository.FindById(id);
    if (current == null) return new SubscriptionResponse("Subscription not found");

    subscription.CopyTo(current);

    try {
      repository.Update(current);
      await unitOfWork.Complete();
      return new SubscriptionResponse(subscription);

    } catch (Exception e) {
      return new SubscriptionResponse($"An error occurred while updating the subscription: {e.Message}");
    }

  }

  public async Task <SubscriptionResponse> Delete(long id) {
    var current = await repository.FindById(id);
    if (current == null) {
      return new SubscriptionResponse("Subscription not found");
    }

    try {
      repository.Remove(current);
      await unitOfWork.Complete();
      return new SubscriptionResponse(current);

    } catch (Exception e) {
      return new SubscriptionResponse($"An error occurred while deleting the subscription: {e.Message}");
    }
  }
}
