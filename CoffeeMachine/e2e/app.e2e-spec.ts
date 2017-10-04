import { CoffeeMachineAppPage } from './app.po';

describe('coffee-machine-app App', () => {
  let page: CoffeeMachineAppPage;

  beforeEach(() => {
    page = new CoffeeMachineAppPage();
  });

  it('should display welcome message', done => {
    page.navigateTo();
    page.getParagraphText()
      .then(msg => expect(msg).toEqual('Welcome to app!!'))
      .then(done, done.fail);
  });
});
