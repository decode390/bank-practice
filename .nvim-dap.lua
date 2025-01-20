local dap =require'dap'

dap.adapters.coreclr = {
  type = 'executable',
  command = 'netcoredbg',
  args = {'--interpreter=vscode'},
}

dap.configurations.cs = {
  {
    type = 'coreclr',
    name = 'launch - netcoredbg',
    request = 'launch',
    program = function()
      return vim.fn.getcwd() .. '/Web.API/bin/Debug/net8.0/Web.API.dll'
    end,
    env = {
      ASPNETCORE_ENVIRONMENT='Development',
      ASPNETCORE_URLS='https://localhost:7229'
    },
  }
}
