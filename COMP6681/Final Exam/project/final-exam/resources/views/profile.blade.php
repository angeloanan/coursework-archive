<x-layout title="Change profile">
  <div class="max-w-screen-lg w-full bg-neutral-100 grid grid-cols-6 mx-auto gap-2 my-4">
    {{-- Image --}}
    <div class="col-span-2">
      <img src="{{ asset('storage/' . Auth::user()->display_picture_link) }}" alt=""
        class="w-full h-full object-cover">
    </div>

    {{-- Form --}}
    <div class="col-span-4">
      @if ($errors->updateData->any())
        <div class="w-full bg-red-200 rounded-lg p-4 my-4">
          <span class="text-red-900 font-medium text-lg">Something went wrong!</span>
          <ul class="list-disc">
            @foreach ($errors->updateData->all() as $error)
              <li class="text-red-900">{{ $error }}</li>
            @endforeach
          </ul>
        </div>
      @endif

      <form method="POST" action="/profile" enctype="multipart/form-data" class="grid grid-cols-2 my-4 gap-2">
        {{ csrf_field() }}

        <label class="flex flex-col gap-2">
          {{ __('firstName') }}
          <input type="text" name="firstName" maxlength="25" value="{{ Auth::user()->first_name }}" required>
        </label>

        <label class="flex flex-col gap-2">
          {{ __('lastName') }}
          <input type="text" name="lastName" maxlength="25" value="{{ Auth::user()->last_name }}" required>
        </label>
        <label class="flex flex-col gap-2">
          {{ __('email') }}
          <input type="email" name="email" value="{{ Auth::user()->email }}" required>
        </label>

        <label class="flex flex-col gap-2 shrink-0">
          {{ __('role') }}
          <select name="role">
            <option value="user">{{ __('roleUser') }}</option>
            <option value="admin" {{ Auth::user()->role->role_name == 'admin' ? 'selected=true' : 'disabled=true' }}>
              {{ __('roleAdmin') }}</option>
          </select>
        </label>

        <div class="flex flex-col gap-2 shrink-0">
          {{ __('gender') }}
          <div class="flex gap-4">
            <label>
              <input type="radio" name="gender" value="male"
                checked="{{ Auth::user()->gender->gender_desc == 'male' }}"> {{ __('genderMale') }}
            </label>
            <label>
              <input type="radio" name="gender" value="female"
                checked="{{ Auth::user()->gender->gender_desc == 'female' }}"> {{ __('genderFemale') }}
            </label>
          </div>
        </div>

        <label class="flex flex-col gap-2 shrink-0">
          {{ __('pfp') }}
          <input type="file" name="pfp" accept="image/png, image/jpeg">
        </label>

        <label class="flex flex-col gap-2 shrink-0">
          {{ __('password') }}
          <input type="password" name="password" minlength="8" autocomplete="on" required>
        </label>

        <label class="flex flex-col gap-2 shrink-0">
          {{ __('confirmPassword') }}
          <input type="password" name="confirmPassword" minlength="8" autocomplete="on" required>
        </label>

        <button class="px-3 py-2 bg-yellow-300 text-yellow-900 rounded text-lg">{{ __('formSubmit') }} &rarr;</button>

      </form>
    </div>
  </div>
</x-layout>
