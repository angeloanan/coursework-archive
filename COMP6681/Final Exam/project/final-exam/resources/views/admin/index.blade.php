<x-layout>
  <div class="my-8 w-full max-w-screen-sm mx-auto">

    <table class="table-fixed w-full">
      <thead>
        <tr class="border-b-2 border-neutral-500">
          <td>{{ __('adminPageAccountListAccount') }}</td>
          <td>{{ __('adminPageAccountListAction') }}</td>
        </tr>
      </thead>

      <tbody>
        @foreach ($users as $user)
          <tr class="border-b border-neutral-300">
            <td>{{ $user->first_name }} {{ $user->last_name }} - {{ $user->role->role_name }}</td>
            <td class="flex gap-2 justify-end">
              <a href="{{ '/admin/changeRole?id=' . $user->account_id }}" class="text-blue-900 font-medium underline">
                {{ __('adminPageAccountListActionUpdateRole') }}
              </a>
              <a href="{{ '/admin/deleteUser?id=' . $user->account_id }}" class="text-blue-900 font-medium underline">
                {{ __('adminPageAccountListActionDeleteRole') }}
              </a>
            </td>
          </tr>
        @endforeach
      </tbody>

    </table>
  </div>
</x-layout>
