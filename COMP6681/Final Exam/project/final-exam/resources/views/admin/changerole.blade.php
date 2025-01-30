<x-layout>
  <div class="mx-auto w-full max-w-screen-sm my-8">
    <h1 class="text-lg font-semibold underline">{{ $user->first_name }} {{ $user->last_name }}</h1>

    <form class="gap-4 my-2" method="POST" action="{{ '/admin/changeRole?id=' . $user->account_id }}">
      {{ csrf_field() }}

      <span>Role:</span>

      <input type="hidden" name="id" value="{{ $user->account_id }}">

      <select name="role">
        <option value="admin">{{ __('roleAdmin') }}</option>
        <option value="user">{{ __('roleUser') }}</option>
      </select>

      <button type="submit" class="block my-4 bg-yellow-400 text-yellow-900 px-4 py-2 rounded font-medium">
        {{ __('formSubmit') }}
      </button>
    </form>
  </div>
</x-layout>
