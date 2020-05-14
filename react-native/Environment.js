const ENV = {
  dev: {
    apiUrl: 'http://localhost:44304',
    oAuthConfig: {
      issuer: 'http://localhost:44304',
      clientId: 'AbpShop_App',
      clientSecret: '1q2w3e*',
      scope: 'AbpShop',
    },
    localization: {
      defaultResourceName: 'AbpShop',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44304',
    oAuthConfig: {
      issuer: 'http://localhost:44304',
      clientId: 'AbpShop_App',
      clientSecret: '1q2w3e*',
      scope: 'AbpShop',
    },
    localization: {
      defaultResourceName: 'AbpShop',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};
