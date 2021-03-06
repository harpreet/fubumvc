﻿using FubuMVC.Core.Runtime;

namespace FubuMVC.Core.Security
{
    public class AuthorizationPolicy<TModel> : IAuthorizationPolicy where TModel : class
    {
        private readonly IAuthorizationRule<TModel> _innerRule;

        public AuthorizationPolicy(IAuthorizationRule<TModel> innerRule)
        {
            _innerRule = innerRule;
        }

        public AuthorizationRight RightsFor(IFubuRequest request)
        {
            return _innerRule.RightsFor(request.Get<TModel>());
        }
    }
}