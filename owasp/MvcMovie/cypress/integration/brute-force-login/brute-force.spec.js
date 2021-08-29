describe('login form', () => {
  it('logs in', () => {
    let loginDetails = [
      ['phil', 'password1'],
      ['phil', 'password2'],
      ['phil', 'password3'],
      ['phil', 'password4'],
      ['phil', 'password5'],
      ['phil', 'password6'],
      ['phil', 'password7'],
      ['phil', 'password8'],
      ['phil', 'password9'],
      ['phil', 'Password1'],
      ['phil', 'Password2'],
      ['phil', 'Password3'],
      ['phil', 'Password4'],
      ['phil', 'Password5'],
      ['phil', 'Password6'],
      ['phil', 'Password7'],
      ['phil', 'Password8'],
      ['phil', 'Password9'],
      ['phil', 'Password1!']
    ];

    cy.visit('/')
    
    loginDetails.forEach(loginDetail => {
      cy.get('input[name="username"]').type(loginDetail[0]);
      cy.get('input[name="password"]').type(loginDetail[1]);
      cy.get("form").submit();
      cy.contains('Invalid Account')
    });
  })
})
