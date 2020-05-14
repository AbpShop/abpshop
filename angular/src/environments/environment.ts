export const environment = {
  production: false,
  application: {
    name: 'AbpShop',
    logoUrl: ''
  },
  oAuthConfig: {
    issuer: 'https://localhost:44304',
    clientId: 'AbpShop_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'AbpShop',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44304'
    }
  },
  localization: {
    defaultResourceName: 'AbpShop'
  }
};
