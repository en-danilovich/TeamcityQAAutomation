# TeamcityQAAutomation

## Setting up Selenium Grid using Docker

Here is an example of running selenium hub and a single selenium node, and connecting Playwright to the hub. Note that hub and node have different IPs, and we pass SE_NODE_GRID_URL environment variable pointing to the hub when starting node containers.

First start the hub container and one or more node containers. [Playwright - Selenium Grid (experimental)](https://playwright.dev/dotnet/docs/selenium-grid)

```bash
docker run -d -p 4442-4444:4442-4444 --name selenium-hub selenium/hub:4.3.0-20220726
docker run -d -p 5555:5555 \
    --shm-size="2g" \
    -e SE_EVENT_BUS_HOST=<selenium-hub-ip> \
    -e SE_EVENT_BUS_PUBLISH_PORT=4442 \
    -e SE_EVENT_BUS_SUBSCRIBE_PORT=4443 \
    -e SE_NODE_GRID_URL="http://<selenium-hub-ip>:4444"
    selenium/node-chrome:4.3.0-20220726

# Alternatively for arm architecture
docker run -d -p 4442-4444:4442-4444 --name selenium-hub seleniarm/hub:4.3.0-20220728
docker run -d -p 5555:5555 \
    --shm-size="2g" \
    -e SE_EVENT_BUS_HOST=<selenium-hub-ip> \
    -e SE_EVENT_BUS_PUBLISH_PORT=4442 \
    -e SE_EVENT_BUS_SUBSCRIBE_PORT=4443 \
    -e SE_NODE_GRID_URL="http://<selenium-hub-ip>:4444"
    seleniarm/node-chromium:103.0
```



## Running Tests on Remote Selenium Grid

To run the tests using .NET on a remote Selenium Grid, you need to set the `SELENIUM_REMOTE_URL` environment variable. This variable specifies the host and port of your Selenium Grid.

Use the following command to set the environment variable and run the tests:

```bash
set SELENIUM_REMOTE_URL=http://{host}:{port} && dotnet test