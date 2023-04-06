redirectToCheckout = function (sessionId) {
    var stripe = Stripe("pk_test_51MtZ9fIhE6AfLza2fE7qIOOJ09d9i5TypKXzxO1s6VeGWCQQSHvhwnzoq0QJ9kEgC8gqS63eblXVwHPbeAz67p4i00g3Nb5qhc")
    stripe.redirectToCheckout({ sessionId: sessionId });
}