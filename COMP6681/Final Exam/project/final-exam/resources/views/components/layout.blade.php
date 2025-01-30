<!DOCTYPE html>
<html>

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <link href="{{ asset('css/app.css') }}" rel="stylesheet">
  <title>{{ isset($title) ? $title . ' « Amazing E-Grocery' : 'Amazing E-Grocery' }}</title>
</head>

<body class="min-h-screen w-full flex flex-col">
  <x-header />

  <main class="grow w-full">
    {{ $slot }}
  </main>

  <x-footer />
</body>

</html>
