# testingfunctionalcode.net
[![Build](https://github.com/LearnWithLlew/TestingFunctionalCodeKata.Net/actions/workflows/build.yml/badge.svg)](https://github.com/LearnWithLlew/TestingFunctionalCodeKata.Net/actions/workflows/build.yml)

<!-- toc -->
## Contents

  * [Hints](#hints)<!-- endToc -->

## Hints
If you want to test with VerifyAll here is the sample of the code:

<!-- snippet: verify_all -->
<a id='snippet-verify_all'></a>
```cs
Approvals.VerifyAll("sin", new[] { 0.1 }, d => $"sin({d}) = {TrigMath.Sin(d)} ");
```
<sup><a href='/TestingFunctionalCodeKata.Net/Samples/ApprovalSamples.cs#L19-L21' title='Snippet source file'>snippet source</a> | <a href='#snippet-verify_all' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->
